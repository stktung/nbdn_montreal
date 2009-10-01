namespace nothinbutdotnetstore.web.core
{
    public interface ResponseEngine 
    {
        void display<Model>(Model model);
    }
}