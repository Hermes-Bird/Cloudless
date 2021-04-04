import {Field, Form, Formik} from 'formik'
import React from 'react'
import {IRegisterFormValues} from '../models/profile'
import rootStore from '../stores/rootStore'

const initialValues: IRegisterFormValues = {
    username: '',
    email: '',
    password: '',
    repeatedPassword: ''
}

const MyComponent: React.FC<{changeForm: () => void}> = ({changeForm}) => {
    return <Formik initialValues={initialValues} onSubmit={rootStore.userStore.register}>
        {
            ({isSubmitting, values}) => (
                <Form className="auth-form">
                    <p>Регистрация</p>
                    <img src="" alt=""/>
                    <Field name="username" type="text" placeholder="Username"/>

                    <img src="" alt=""/>
                    <Field name="email" type="text" placeholder="Почта"/>

                    <img src="" alt=""/>
                    <Field name="password" type="password" placeholder="Пароль"/>

                    <img src="" alt=""/>
                    <Field name="repeatedPassword" type="password" placeholder="Повторить пароль"/>

                    <button className="button">Зарегистрироваться</button>
                    <p onClick={changeForm} className="change-form-text">Уже есть аккаунт?</p>
                    {
                        // DEV
                        JSON.stringify(values, null, 2)
                    }
                </Form>
            )
        }
    </Formik>
}

export default MyComponent
