
namespace Fabrics
{
    interface ISchema
    {
        Model.Database GetSchema(string connectionString, Model.DatabaseTypes type);
    }
}
