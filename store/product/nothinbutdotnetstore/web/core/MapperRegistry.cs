namespace nothinbutdotnetstore.web.core
{
    public interface MapperRegistry {
        Mapper<Input,Output> get_mapper_to_map<Input,Output>();
    }
}