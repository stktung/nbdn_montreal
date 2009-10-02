include FileTest

class SqlRunner
  def initialize(settings = Hash.new("Not found"))
    @sql_tool = settings.fetch(:sql_tool,File.join(ENV['SystemDrive'],'program files','microsoft sql server','100','tools','binn','osql.exe'))
    @command_line_args = settings.fetch(:command_line_args, '-b -i')
    @connection_string = settings.fetch(:connection_string,"-E")
  end

  def process_sql_files(files)
      files.each do|file|
        begin
            sh "#{@sql_tool} #{@connection_string} #{@command_line_args} #{file}"
        rescue 
          puts("Error processing sql file:#{file}")
          raise
        end
      end
  end
end

class LocalSettings
  attr_reader :settings

  def [](setting)
    @settings[setting]
  end

  def each_pair
    @settings.each_key do|key,value|
      yield key,@settings[key]
    end
  end
end

class TemplateFile
  attr_reader :template_file_name
  attr_reader :output_file_name

  def initialize(template_file_name)
    @template_file_name = template_file_name
    @output_file_name = template_file_name.gsub('.template','')
  end

  def generate(settings_dictionary)
    generate_to(@output_file_name,settings_dictionary)
  end

  def generate_to_directory(output_directory,settings_dictionary)
    generate_to(File.join(output_directory,File.basename(@output_file_name)),settings_dictionary)
  end

  def generate_to_directories(output_directories,settings_dictionary)
    output_directories.each do |directory|
      generate_to_directory(directory,settings_dictionary)
    end
  end

  def generate_to(output_file,settings_dictionary)
     File.delete?(output_file) 

     File.open_for_write(output_file) do|generated_file|
       File.open_for_read(@template_file_name) do|template_line|
         settings_dictionary.each_key do|key|
           template_line = template_line.gsub("@#{key}@","#{settings_dictionary[key]}")
         end
         generated_file.puts(template_line)
       end
     end
  end

  def to_s()
    "Template File- Template:#{@template_file_name} : Output:#{@output_file_name}"
  end

end

class TemplateFileList
  @template_files
  def initialize(files_pattern)
    @template_files  = []
    FileList.new(files_pattern).each do|file| 
      @template_files.push(TemplateFile.new(file))
    end
  end

  def each()
    @template_files.each do |file|
      yield file
    end
  end

  def generate_all_output_files(settings)
    @template_files.each do |file|
      file.generate(settings)
    end
  end
end

class MbUnitRunner
	def initialize(items)
		@source_dir = items.fetch(:source_dir, 'product')
		@mbunit_dir = items.fetch(:mbunit_dir, 'thirdparty/mbunit')
		@test_results_dir = items.fetch(:test_results_dir, 'artifacts')
		@compile_target = items.fetch(:compile_target, 'debug')
		@category_to_exclude = items.fetch(:category_to_exclude, 'missing')
		@show_report = items.fetch(:show_report, true)
    @report_type = items.fetch(:report_type,'XML')
	end
	
	def execute_tests(assemblies)
		Dir.mkdir @test_results_dir unless exists?(@test_results_dir)
		
		assemblies.each do |assem|
      sh build_command_line_for(assem)
		end
	end

  def build_command_line_for(assembly)
			file = File.expand_path("#{@test_results_dir
      }/#{assembly}.dll")
      "#{@mbunit_dir}/mbunit.cons.exe #{file} /rt:#{@report_type} /rnf:#{assembly}.dll-results /rf:#{@test_results_dir} #{'/sr' if @show_report} /ec:#{@category_to_exclude}"
  end
end

class MSBuildRunner
	def self.compile(attributes)
		version = attributes.fetch(:clrversion, 'v3.5')
		compile_target = attributes.fetch(:compile_target, 'debug')
	    solution_file = attributes[:solution_file]
		
		framework_dir = File.join(ENV['windir'].dup, 'Microsoft.NET', 'Framework', 'v3.5')
		msbuild_file = File.join(framework_dir, 'msbuild.exe')
		
		sh "#{msbuild_file} #{solution_file} /property:Configuration=#{compile_target} /property:OutDir=../../artifacts/ /t:Build"
	end
end

class File
  def self.open_for_read(file)
     File.open(file,'r').each do|line|
       yield line
     end
  end

  def self.read_all_text(file)
    contents = ''
    File.open_for_read(file) do |line|
      contents += line
    end
  end

  def self.delete?(file)
    File.delete(file) if File.exists?(file)
  end

  def self.open_for_write(file)
     File.open(file,'w') do|new_file|
       yield new_file
     end
  end

  def self.base_name_without_extensions(file)
    File.basename(file,'.*')
  end

 end

class BDDDocRunner
  def initialize(settings = Hash.new('missing'))
    @output_folder = settings.fetch(:output_folder,'artifacts')
    @observation_attribute = settings.fetch(:observation_attribute,'ObservationAttribute')
    @bdddoc_folder = settings.fetch(:bdddoc_folder,'thirdparty\developwithpassion.bdddoc')
    @mbunit_test_output_folder = settings.fetch(:mbunit_test_output_folder,'artifacts')
    @developwithpassion_bdddoc_exe = settings.fetch(:bdddoc_exe,'developwithpassion.bdddoc.exe')
    @logo_jpg = settings.fetch(:logo_jpg,File.join(@bdddoc_folder,'developwithpassion.bdddoc-logo.jpg'))
    @css = settings.fetch(:css,File.join(@bdddoc_folder,'developwithpassion.bdddoc.css'))
  end

  def run(test_library)
    test_file = File.basename(test_library)
    output_file = "#{File.join(@output_folder,test_file)}.developwithpassion.bdddoc.html"
    mbunit_test_output_file = "#{File.join(@mbunit_test_output_folder,test_file)}-results.xml"
    sh "#{File.join(@bdddoc_folder,@developwithpassion_bdddoc_exe)} #{test_library} #{@observation_attribute} #{output_file} #{mbunit_test_output_file}"
   FileUtils.cp @logo_jpg,@output_folder
   FileUtils.cp @css,@output_folder
  end
end

