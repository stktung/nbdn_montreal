namespace nothinbutdotnetstore.infrastructure
{
    public static class StringExtensions
    {
        public static string format(this string format, params object[] args){
            return string.Format(format, args);
        }
    }
}