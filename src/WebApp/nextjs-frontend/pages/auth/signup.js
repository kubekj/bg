import style from "../../styles/log-in.module.css";
import Header from "../../components/auth/header";
import ButtonsSection from "../../components/auth/buttons-section";
import SignInContent from "../../components/auth/sign-in-content";
import Auth from "../../components/layouts/Auth";

const SignIn = () => {
    return (
        <div className={style.container}>
            <div>
                <Header
                    headerText='Create an account'
                    info='Glad to see you here! Please provide us with required information'
                />
                <SignInContent/>
                <ButtonsSection
                    leftBottomSectionText='Already have an account?'
                    rightBottomSectionText='Sign in!'
                />
            </div>
        </div>
    );
};

export default SignIn;

SignIn.layout = Auth;
