import axios from 'axios'
import {ILoginFormValues, IRegisterFormValues, LoginData, User} from '../models/profile'

const baseUrl = "https://localhost:5001/api"

axios.defaults.baseURL = baseUrl

const accountAgent = {
    register: (user: IRegisterFormValues): Promise<User> => axios.post<User>('account/register', user).then(r => r.data),
    login: (userCredentials: ILoginFormValues): Promise<LoginData> => axios.post('account/login', userCredentials).then(r => r.data)
}

const agent = {
    accountAgent
}

export default agent