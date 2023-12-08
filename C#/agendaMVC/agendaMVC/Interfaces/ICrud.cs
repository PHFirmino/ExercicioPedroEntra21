namespace agendaMVC.Interfaces
{
    public interface ICrud<T>
    {
        void mostrar(List<T> t);
        bool criar(T t);
        bool att(T t);
        bool deletar(T t);
    }
}