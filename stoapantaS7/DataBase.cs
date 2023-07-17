using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace stoapantaS7
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
