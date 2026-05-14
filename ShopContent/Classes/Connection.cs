using System.Data.SqlClient;

namespace ShopContent.Classes
{
    public class Connection
    {
        /// <summary> Строка подключения к серверу
        private static readonly string config = "server=;" +
            "Trusted_Connection=No;" +
            "DataBase=ShopContent;" +
            "User=***;" +
            "PWD=***";

        /// <summary> Метод открытия соединения
        public static SqlConnection OpenConnection()
        {
            // Создаём поключение к базе данных
            SqlConnection connection = new SqlConnection(config);
            // Открываем соединение
            connection.Open();
            // Возвращаем соединение
            return connection;
        }

        /// <summary> Метод выпонения запросов
        public static SqlDataReader Query(string SQL, out SqlConnection connection)
        {
            // Создаём подключение к базе данных
            connection = OpenConnection();
            // Возвращаем данные
            return new SqlCommand(SQL, connection).ExecuteReader();
        }

        /// <summary> Закрытие подключение к БД
        public static void CloseConnection(SqlConnection connection)
        {
            // Закрываем подключение
            connection.Close();
            SqlConnection.ClearPool(connection);
        }
    }
}