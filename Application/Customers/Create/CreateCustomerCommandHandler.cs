namespace Application.Customers.Create;

using System.Threading;
using System.Threading.Tasks;
using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;
using MediatR;

internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }


    public async Task<Unit> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        if(PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
            throw new ArgumentException(nameof(phoneNumber));

        var customer = new Customer
        (
            new CustomerId(Guid.NewGuid()),
            command.Name,
            command.LastName,
            command.Email,
            phoneNumber,
            true
        );

        await _customerRepository.Add(customer);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}