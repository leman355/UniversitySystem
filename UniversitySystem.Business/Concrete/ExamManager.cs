using AutoMapper;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.ExamDtos;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Entities;

namespace UniversitySystem.Business.Concrete
{
    public class ExamManager : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;

        public ExamManager(IExamRepository examRepository, IMapper mapper)
        {
            _examRepository = examRepository;
            _mapper = mapper;
        }

        public async Task<List<ExamToListDto>> GetAllExams()
        {
            var exams = await _examRepository.GetAllExams();
            return _mapper.Map<List<ExamToListDto>>(exams);
        }

        public async Task<ExamToListDto> GetExamById(int examId)
        {
            var exam = await _examRepository.GetExamById(examId);
            return _mapper.Map<ExamToListDto>(exam);
        }

        public async Task<ExamToAddDto> CreateExam(ExamToAddDto dto)
        {
            var exam = _mapper.Map<Exam>(dto);
            var createdExam = await _examRepository.CreateExam(exam);
            return _mapper.Map<ExamToAddDto>(createdExam);
        }

        public async Task<ExamToUpdateDto> UpdateExam(int examId, ExamToUpdateDto dto)
        {
            var existingExam = await _examRepository.GetExamById(examId);

            if (existingExam == null)
            {
                return null;
            }

            _mapper.Map(dto, existingExam);

            var updatedExam = await _examRepository.UpdateExam(existingExam);
            return _mapper.Map<ExamToUpdateDto>(updatedExam);
        }

        public async Task DeleteExamById(int examId)
        {
            await _examRepository.DeleteExamById(examId);
        }

        public async Task<List<ShortExamToListDto>> GetExamsByCourseId(int courseId)
        {
            var exams = await _examRepository.GetExamsByCourseId(courseId);
            return _mapper.Map<List<ShortExamToListDto>>(exams);
        }
    }
}
