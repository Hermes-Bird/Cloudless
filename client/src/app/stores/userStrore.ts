import {ILoginFormValues, IRegisterFormValues, User} from '../models/profile'
import {makeAutoObservable} from 'mobx'
import agent from '../api/agent'
import rootStore from './rootStore'

export class UserStrore {
    user: User | null = null;

    constructor() {
        makeAutoObservable(this)
    }

    get isLoggedIn(): boolean {
        return !!this.user
    }

    login = async (user: ILoginFormValues) => {
        try {
            const loginData = await agent.accountAgent.login(user)
            rootStore.commonStore.token = loginData.token
        } catch (e) {
            throw e;
        }
   }

   register = async (user: IRegisterFormValues) => {
        try {
            const newUser = await agent.accountAgent.register(user)
            console.log(newUser)
        } catch (e) {
            throw e
        }
   }
}