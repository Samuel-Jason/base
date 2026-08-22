using System.Data;

namespace ConsoleApp1.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}