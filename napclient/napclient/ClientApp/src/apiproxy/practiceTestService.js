import axios from 'axios';

const baseRestUrl = process.env.REACT_APP_REST_API_ENDPOINT;

class PracticeTestService {
    static async postUserTestTextRecord(userTestRecord) {
        return await axios.post(`${baseRestUrl}/practicetest`, userTestRecord);
    }

}

export default PracticeTestService;