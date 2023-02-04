import style from "../../styles/log-in.module.css";
import Header from "../../components/auth/header";
import LogInContent from "../../components/auth/log-in-content";
import Auth from "../../components/layouts/Auth";

const LogIn = () => {
  return (
    <div className={style.container}>
      <div>
        <Header
          headerText='Log in to your account'
          info='Welcome back! Please enter your details'
        />
        <LogInContent />
      </div>
    </div>
  );
};

export default LogIn;

LogIn.layout = Auth;
