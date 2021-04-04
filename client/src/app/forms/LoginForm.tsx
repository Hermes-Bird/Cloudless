import {Field, Form, Formik} from 'formik'
import React from 'react'
import {ILoginFormValues} from '../models/profile'
import rootStore from '../stores/rootStore'

const initialValues: ILoginFormValues = {
    email: '',
    password: ''
}

const LoginForm: React.FC<{changeForm: () => void}> = ({changeForm}) => {
    return <Formik initialValues={initialValues} onSubmit={rootStore.userStore.login}>
        {({values, isSubmitting}) => (
        <Form className="auth-form">
            <p>Авторизация</p>
            <img src="" alt=""/>
            <Field name="email" type="text" placeholder="Почта"/>

            <img src="" alt=""/>
            <Field name="password" type="password" placeholder="Пароль"/>

            <button type="submit" disabled={isSubmitting} className="button">Войти</button>
            <p onClick={changeForm} className="change-form-text">Регистрация</p>
            {
                // DEV
                JSON.stringify(values, null, 2)
            }
        </Form>
        )}
    </Formik>
}

export default LoginForm
