namespace nothinbutdotnetstore.web.core
{
    public interface ViewRegistry
    {
        ViewForModel<Model> find_view_that_can_process<Model>();
    }
}