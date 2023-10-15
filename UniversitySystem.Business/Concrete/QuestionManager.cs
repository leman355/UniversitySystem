using AutoMapper;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.QuestionDtos;
using UniversitySystem.Entities;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Business.DTO.AnswerDtos;

namespace UniversitySystem.Business.Concrete
{
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionManager(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<List<QuestionToListDto>> GetAllQuestions()
        {
            var questions = await _questionRepository.GetAllQuestions();
            return _mapper.Map<List<QuestionToListDto>>(questions);
        }

        public async Task<QuestionToListDto> GetQuestionById(int questionId)
        {
            var question = await _questionRepository.GetQuestionById(questionId);
            return _mapper.Map<QuestionToListDto>(question);
        }

        public async Task<QuestionToAddDto> CreateQuestion(QuestionToAddDto dto)
        {
            var question = _mapper.Map<Question>(dto);
            var createdQuestion = await _questionRepository.CreateQuestion(question);
            return _mapper.Map<QuestionToAddDto>(createdQuestion);
        }

        public async Task<QuestionToUpdateDto> UpdateQuestion(int questionId, QuestionToUpdateDto dto)
        {
            var existingQuestion = await _questionRepository.GetQuestionById(questionId);

            if (existingQuestion == null)
            {
                return null;
            }

            _mapper.Map(dto, existingQuestion);

            var updatedQuestion = await _questionRepository.UpdateQuestion(existingQuestion);
            return _mapper.Map<QuestionToUpdateDto>(updatedQuestion);
        }

        public async Task DeleteQuestionById(int questionId)
        {
            await _questionRepository.DeleteQuestionById(questionId);
        }

        public async Task<List<ShortAnswerToListDto>> GetQuestionAnswers(int questionId)
        {
            var answers = await _questionRepository.GetQuestionAnswers(questionId);
            return _mapper.Map<List<ShortAnswerToListDto>>(answers);
        }

        public async Task<List<ShortAnswerToListDto>> GetCorrectAnswersForQuestion(int questionId)
        {
            var correctAnswers = await _questionRepository.GetCorrectAnswersForQuestion(questionId);
            return _mapper.Map<List<ShortAnswerToListDto>>(correctAnswers);
        }
    }
}
