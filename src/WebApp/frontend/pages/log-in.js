import style from './log-in.module.css'
import Header from "../components/register-login/header";

const LogIn = () => {

    return(
      <div className={style.container}>
          <div className={style.content}>
                <Header />
          </div>
      </div>
    );
}

export default LogIn;