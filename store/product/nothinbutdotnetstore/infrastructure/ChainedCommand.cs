namespace nothinbutdotnetstore.infrastructure
{
    public class ChainedCommand : Command
    {
        Command first;
        Command second;

        public ChainedCommand(Command first, Command second)
        {
            this.first = first;
            this.second = second;
        }

        public void run()
        {
            first.run();
            second.run();
        }
    }
}