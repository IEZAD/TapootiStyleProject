using _0_Framework.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace _0_Framework.Infrastructure.Common
{
    public abstract class QueryUnitOfWork<TEntity> : IQueryUnitOfWork
            where TEntity : DbContext
    {
        public QueryUnitOfWork(Options options) : base()
        {
            Options = options;
        }

        // **********
        protected Options Options { get; set; }
        // **********

        // **********
        // **********
        // **********
        private TEntity _databaseContext;
        // **********

        // **********

        protected TEntity DatabaseContext
        {
            get
            {
                if (_databaseContext == null)
                {
                    var optionsBuilder = new DbContextOptionsBuilder<TEntity>();

                    switch (Options.Provider)
                    {
                        case Provider.SqlServer:
                            {
                                optionsBuilder.UseSqlServer(connectionString: Options.ConnectionString);

                                break;
                            }

                        case Provider.MySql:
                            {
                                //optionsBuilder.UseMySql
                                //	(connectionString: Options.ConnectionString);

                                break;
                            }

                        case Provider.Oracle:
                            {
                                //optionsBuilder.UseOracle
                                //	(connectionString: Options.ConnectionString);

                                break;
                            }

                        case Provider.PostgreSQL:
                            {
                                //optionsBuilder.UsePostgreSQL
                                //	(connectionString: Options.ConnectionString);

                                break;
                            }

                        //case Provider.InMemory:
                        //{
                        //	optionsBuilder.UseInMemoryDatabase
                        //		(databaseName: Options.InMemoryDatabaseName);

                        //	break;
                        //}

                        default:
                            {
                                break;
                            }
                    }

                    _databaseContext =
                        (TEntity)Activator.CreateInstance
                        (type: typeof(TEntity), args: optionsBuilder.Options);
                }

                return _databaseContext;
            }
        }
        // **********
        // **********
        // **********

        // **********
        /// <summary>
        /// To detect redundant calls
        /// </summary>
        public bool IsDisposed { get; protected set; }
        // **********

        /// <summary>
        /// Public implementation of Dispose pattern callable by consumers.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO: dispose managed state (managed objects).

                if (_databaseContext != null)
                {
                    _databaseContext.Dispose();
                    _databaseContext = null;
                }
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            IsDisposed = true;
        }

        ~QueryUnitOfWork()
        {
            Dispose(false);
        }
    }
}
