using _0_Framework.Application;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleAgg;
using System.Collections.Generic;

namespace AccountManagement.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;

        public RoleApplication(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public OperationResult Create(CreateRole command)
        {
            var operation = new OperationResult();
            if (_roleRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var permissions = new List<Permission>();
            foreach (var code in command.Permissions)
            {
                if (code > 0)
                {
                    permissions.Add(new Permission(code));
                }
            }
            //command.Permissions.ForEach(code => permissions.Add(new Permission(code)));
            var role = new Role(command.Name, permissions);
            _roleRepository.Create(role);
            _roleRepository.SaveChanges();
            return operation.Succcedded();
        }

        public OperationResult Edit(EditRole command)
        {
            var operation = new OperationResult();
            var role = _roleRepository.Get(command.Id);
            if (role == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_roleRepository.Exists(x => x.Name == command.Name && x.id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            //var permissions = new List<Permission>();
            //command.Permissions.ForEach(code => permissions.Add(new Permission(code)));

            var permissions = new List<Permission>();
            foreach (var code in command.Permissions)
            {
                if (code > 0)
                {
                    permissions.Add(new Permission(code));
                }
            }

            role.Edit(command.Name, permissions);
            _roleRepository.SaveChanges();
            return operation.Succcedded();
        }

        public EditRole GetDetails(long id)
        {
            return _roleRepository.GetDetails(id);
        }

        public List<RoleViewModel> List()
        {
            return _roleRepository.List();
        }
    }
}