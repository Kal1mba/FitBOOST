using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Xamarin.Forms;

namespace FitBOOST
{
    internal class DataBaseConnection
    {
        //Глобальные переменные параметры входа
        public static string ServerName;
        public static string DataBaseName;
        public static string UserLogin;
        public static string UserPassword;

        // Наследуем класс для подключение к базе данных
        SqlConnection connectionString = new SqlConnection($"Data Source={ServerName};" +
            $" Initial Catalog={DataBaseName}; User ID={UserLogin}; Password={UserPassword}");

        

        public void openConnection()
        {//Функция на открытия подключения с проверкой
            if (connectionString.State == System.Data.ConnectionState.Closed)
            {
                connectionString.Open();
            }

        }
        public void closeConnection()
        {//Функция на закрытие подключения с проверкой
            if (connectionString.State == System.Data.ConnectionState.Open)
            {
                connectionString.Close();
            }
        }
        public SqlConnection getConnection()
        {//Функция на пересылку подключения другим функциям
            return connectionString;
        }
    }
}
