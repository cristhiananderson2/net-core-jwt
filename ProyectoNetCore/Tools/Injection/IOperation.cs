using System;

namespace ProyectoNetCore.Tools
{
    public interface IOperation
    {
        Guid Id { get; }
    }

    public interface IOperationScope : IOperation
    {

    }

    public interface IOperationTransient : IOperation
    {

    }

    public interface IOperationSingleton : IOperation
    {

    }
}