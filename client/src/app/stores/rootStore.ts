import {makeAutoObservable} from 'mobx'
import {CommonStore} from './commonStore'
import {UserStrore} from './userStrore'

class RootStore {
    commonStore: CommonStore
    userStore: UserStrore

    constructor() {
        this.commonStore = new CommonStore()
        this.userStore = new UserStrore()
        makeAutoObservable(this)
    }

}
const rootStore = new RootStore()
export default rootStore