namespace nothinbutdotnetstore.infrastructure
{
    public static class CommandExtensions
    {
        public static Command followed_by(this Command first, Command second){
            return new ChainedCommand(first, second);
        } 
    }
}