// using MediatR;
// using BizBuddy.Application.Common;
// using BizBuddy.Domain.Entities;
// using BizBuddy.Domain.Interfaces;
// using BizBuddy.Application.Common.Interfaces;

// namespace BizBuddy.Application.Features.Persons.Commands;

// public record CreatePersonCommand(string FirstName, string LastName) : IRequest<Result<long>>;

// public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Result<long>>
// {
//     private readonly IApplicationDbContext _context;

//     public CreatePersonCommandHandler(IApplicationDbContext context)
//     {
//         _context = context;
//     }

//     public async Task<Result<long>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
//     {
       

//         // var entity = new Person
//         // {
//         //     FirstName = request.FirstName,
//         //     LastName = request.LastName
//         // };

//         // _context.Persons.Add(entity);
//         await _context.SaveChangesAsync(cancellationToken);

//         return Result<long>.Success(entity.Id);
//     }
// }
