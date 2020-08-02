import axios from 'axios';

const baseRestUrl = process.env.REACT_APP_REST_API_ENDPOINT;

class QuestionService {
    static async getTestResult(userTestId) {
        return await axios.get( `${baseRestUrl}/testresult/${userTestId}`);
    }

    static async getQuestionImage(questionId) {
        return await axios.get(`${baseRestUrl}/question/${questionId}/images`);
    }

    static async getQuestionAudio(questionId){
        return await axios.get(`${baseRestUrl}/question/${questionId}/audio`);
    }
}

export default QuestionService;