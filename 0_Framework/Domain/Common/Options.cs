namespace _0_Framework.Domain.Common
{
    public class Options : object
    {
        // **********
        public Provider Provider { get; set; }
        // **********

        // **********
        public string ConnectionString { get; set; }
        // **********

        // **********
        public string InMemoryDatabaseName { get; set; }
        // **********

        public Options() : base()
        {
        }
    }
}
