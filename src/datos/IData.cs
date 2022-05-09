namespace datos;

public interface IData<T>
{
    public void guardar(List<T> datos);
    public List<T> leer();

}