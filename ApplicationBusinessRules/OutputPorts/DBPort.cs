namespace ApplicationBusinessRules.OutputPorts
{
    public interface DBPort<T>
    {
        T BuscarPorId(int id);
        IEnumerable<T> BuscarTodos();
        void Salvar(T entidade);
        void Atualizar(T entidade);
        void Deletar(int id);
    }
}