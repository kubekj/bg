import style from '../styles/log-in.module.css'
import Header from "../components/register-login/header";
import LogInContent from "../components/register-login/log-in-content";
import ButtonsSection from "../components/register-login/buttons-section";


const LogIn = () => {
    return (
        <div className={style.container}>
            <div>
                <Header headerText="Log in to your account" info="Welcome back! Please enter your details"/>
                <LogInContent/>
                <ButtonsSection topButtonText="Sign in" bottomButtonText="Sign in with Google" leftBottomSectionText="Dont have an account?" rightBottomSectionText="Sign up!"/>
            </div>
        </div>

    );
}

export default LogIn;