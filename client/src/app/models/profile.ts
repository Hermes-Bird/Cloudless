export interface IRegisterFormValues {
    username: string,
    email: string,
    password: string,
    repeatedPassword: string
}

export interface ILoginFormValues {
    email: string,
    password: string
}

export interface UserDetail {
    username: string,
    publicUsername: string
}

export interface User {
    username: string,
    email: string,
    publicUsername: string | null,
    contacts: UserDetail[]
}

export interface LoginData {
    email: string,
    token: string
}