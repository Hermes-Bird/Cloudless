export class CommonStore {
    get token(): string | null {
        return localStorage.getItem('jwt')
    }

    set token(value: string | null){
        console.log(value)
        if (value) localStorage.setItem('jwt', value)
        else localStorage.removeItem('jwt')
    }
}