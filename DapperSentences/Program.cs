using System.Data.SqlClient;
using Dapper;
using DapperSentences.Models;

print("Dapper Sentences");

var res = Execute(ConnectionString.SqlServer, 
    @"INSERT INTO contacto
          (nombre
          ,telefono
          ,celular
          ,correo
          ,direccion
          ,comentario
          )
     VALUES
           (@nombre
           ,@telefono
           ,@celular
           ,@correo
           ,@direccion
           ,@comentario
           )", new { nombre = "Ana Gomez", telefono ="800-650-7743", correo = "email@domain.com", celular = "000-000-0000", direccion = "At Home", comentario = "No Comment"});

print("Inserted: " + res);

var result  = Execute(ConnectionString.SqlServer, "UPDATE contacto   SET correo =@correo WHERE nombre like @name", new { name = "%Emilio%", correo = "email_sample@dummy.com" });

print("Uptaded: " + result);

var contacts = Select<Contact>(ConnectionString.SqlServer, "select * from contacto where nombre like @name", new { name ="%Emilio%"});

contacts.ForEach(contact =>
{
    print($"{contact.id} | {contact.nombre} | { contact.celular} | { contact.correo} | { contact.comentario } | { contact.direccion }");
});

static void print (object obj)
{
    Console.WriteLine(obj);
}

static List<T> Select<T>(string connection, string sql, object? param = null) where T : new()
{
    List<T> data = new ();
      using(var db = new SqlConnection(connection))
    {
        data = db.Query<T>(sql, param).ToList();

    }
    return data;
}

static bool Execute(string connection, string sql, object? param = null)
{
    bool res = true;
    try
    {
        using (var db = new SqlConnection(connection))
        {
            db.Execute(sql, param);

        }
    }
    catch (Exception e)
    {
        print(e.Message);
        res = !res;
    }
    return res;
}