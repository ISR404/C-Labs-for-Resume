using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Configuration;
using Ninject.Modules;

namespace DAL
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetObjectsList(); //Получение всех объектов
        T GetObject(int id); //Получение одного объекта по id
        void Create(T item); //Создание объекта
        void Update(T item); //Обновление объекта
        void Delete(int id); //Удаление объекта по id
        void Save(); // Сохранение изменений

    }

    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Employee>>().To<DapperRepository>().InSingletonScope();
        }
    }

    public class SQLEmpRepository : IRepository<Employee>
    {
        private UserContext db;
        
        public SQLEmpRepository()
        {
            this.db = new UserContext();
        }
        
        public IEnumerable<Employee> GetObjectsList()
        {
            return db.Employees;
        }
        
        public Employee GetObject(int id)
        {
            return db.Employees.Find(id);
        }
        
        public void Create(Employee emp)
        {
            db.Employees.Add(emp);
        }

        public void Update(Employee emp)
        {
            db.Entry(emp).State = EntityState.Modified;
        }
        
        public void Delete(int id)
        {
            Employee emp = db.Employees.Find(id);
            if (emp != null)
                db.Employees.Remove(emp);
        }
        
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }


    public class UserContext : DbContext
    {
        public UserContext() : base("DbConnection")
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }

    public class DapperRepository : IRepository<Employee>
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        public IEnumerable<Employee> GetObjectsList()
        {
            List<Employee> users = new List<Employee>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                users = db.Query<Employee>("SELECT * FROM Employees").ToList();
            }
            return users;
        }

        public Employee GetObject(int id)
        {
            Employee user = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                user = db.Query<Employee>("SELECT * FROM Employees WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return user;
        }

        public void Create(Employee user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Employees (Name, Age, Cash, Pay) VALUES(@Name, @Age, @Cash, @Pay); SELECT CAST(SCOPE_IDENTITY() as int)";
                int userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                user.Id = userId;
            }
            
        }

        public void Update(Employee user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Employees SET Name = @Name, Age = @Age, Cash = @Cash, Pay = @Pay WHERE Id = @Id";
                db.Execute(sqlQuery, user);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Employees WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public void Save()
        {

        }

        public void Dispose()
        {

        }
    }
}
