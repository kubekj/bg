import style from '../styles/log-in.module.css'
import Header from "../components/register-login/header";
import ButtonsSection from "../components/register-login/buttons-section";
import SignInContent from "../components/register-login/sign-in-content";


const SignIn = () => {
    return (
        <div className={style.container}>
            <div>
                <Header headerText="Create an account" info="Glad to see you here! Please provide us with required information"/>
                <SignInContent/>
                <ButtonsSection topButtonText="Get started" bottomButtonText="Sign up with Google" leftBottomSectionText="Already have an account?" rightBottomSectionText="Sign in!"/>
            </div>
        </div>

    );
}

export default SignIn;