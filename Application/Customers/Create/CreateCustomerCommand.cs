namespace Application.Customers.Create;

using MediatR;

public record CreateCustomerCommand
(
    string Name,
    string LastName,
    string Email,
    string PhoneNumber
) : IRequest<Unit>;