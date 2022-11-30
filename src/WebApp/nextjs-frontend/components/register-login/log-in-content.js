import style from './header.module.css'
import Image from 'next/image'
import logo from '../../public/logo.png'

const LogInContent = () => {
    return(
        <div>
            <div className="mb-3">
                <label htmlFor="formGroupExampleInput" className="form-label">Email</label>
                <input type="email" className="form-control" id="formGroupExampleInput"
                       placeholder="f.e. john.doe@gmail.com"/>
            </div>
            <div className="mb-3">
                <label htmlFor="formGroupExampleInput2" className="form-label">Password</label>
                <input type="password" className="form-control" id="formGroupExampleInput2"
                       placeholder="******"/>
            </div>
            <div className={style.bottomSection}>
                <div className="form-check w-50">
                    <input className="form-check-input" type="checkbox" value="" id="flexCheckDefault"/>
                    <label className="form-check-label" htmlFor="flexCheckDefault">
                        Remember for 30 days
                    </label>
                </div>
                <div>
                    <a className={`text-decoration-none`} style={{color: "#98B3DB"}} href="#">Forgot password</a>
                </div>
            </div>
        </div>
    );
}

export default LogInContent;