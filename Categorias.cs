// Creamos la clase Categorías
public class Cateogrias {
    
    /* Se hace uso del enum para poder especificar si la categoría que 
    vamos a usar es para la sección de los estantes o el tipo de producto*/
    public enum Grupos { PRODUCTO = 0, SECCION = 1}

// Se crea la id de la categoría
    private int id =0;

// Se crea la variable del nombre de la categoría
    private string nombre = "";

// Se crea la variable del grupo que automaticamente se pone como default el grupo de Productos
    private int grupo = (int)Grupos.PRODUCTO;

// Se crean los getters y setters de dichos atributos de la clase
    public int Id { get => this.id; set => this.id = value; }
    public string Nombre { get => this.nombre; set => this.nombre = value; }
    public int Grupo { get => this.grupo; set => this.grupo = value; }


}