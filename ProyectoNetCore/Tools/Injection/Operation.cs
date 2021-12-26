using System;

namespace ProyectoNetCore.Tools
{
    public class Operation : IOperationTransient, IOperationScope, IOperationSingleton
    {
        Guid _id;

        public Operation() : this(Guid.NewGuid())
        {

        }

        public Operation(Guid id)
        {
            _id = id;
        }

        public Guid Id => _id;
    }

    public class Operation2
    {
        Guid _id;

        public Operation2() : this(Guid.NewGuid())
        {

        }

        public Operation2(Guid id)
        {
            _id = id;
        }

        public Guid Id => _id;
    }
}