public class Sucursales
{
    private int id_sucursal = 0;
    private Bodega? bodega = null;
    private string nombre = "";
    private string direccion = "";


    public int Id_sucursal { get => this.id_sucursal; set => this.id_sucursal = value; }
    public Bodega? Bodega { get => this.bodega; set => this.bodega = value; }
    public string Nombre { get => this.Nombre; set => this.Nombre = value; }
    public string Direccion { get => this.direccion; set => this.direccion = value; }

    public Sucursales()
	{
	}
}
