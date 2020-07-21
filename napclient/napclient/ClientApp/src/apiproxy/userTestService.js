import axios from 'axios';

const baseRestUrl = process.env.REACT_APP_REST_API_ENDPOINT;

class UserTestService {
    static async getTestProgressPercentage(userTestId) {
        return await axios.get(`${baseRestUrl}/usertest/progress/${userTestId}`);
    }
}

export default UserTestService;