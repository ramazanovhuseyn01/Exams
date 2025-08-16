using Application.DTOs.Lesson;
using Application.Features.Queries.Lesson;
using AutoMapper;
using MediatR;
using Repository.Repositories.Interfaces;

namespace Application.Features.Handlers.Lesson
{
    public class GetAllLessonQueryHandler : IRequestHandler<GetAllLessonQuery, List<LessonListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllLessonQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<LessonListDto>> Handle(GetAllLessonQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var lessons = await _unitOfWork.Repository<Domain.Entities.Lesson>().GetAll();
                var mappingData = _mapper.Map<List<LessonListDto>>(lessons);
                return mappingData;
            }
            catch (Exception ex)
            {
                // məsələn Serilog, ILogger və ya Console
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}