namespace Catalogo.DatabaseSettings
{
    public interface ICatalogoDataBaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}