import style from './header.module.css'


const Header = ({headerText, info}) => {

    return (
        <div>
            <div className={style.header}>
                {/*<Image src="/logo.png" width={56} height={45} alt="BG logo"/>*/}
                <div className={style.imageTest}/>
                <h1 className={`text-center`}>{headerText}</h1>
                <p className="text-center">{info}</p>
            </div>
            {/*<div className="mb-3">*/}
            {/*    <label htmlFor="formGroupExampleInput" className="form-label">Email</label>*/}
            {/*    <input type="email" className="form-control" id="formGroupExampleInput"*/}
            {/*           placeholder="f.e. john.doe@gmail.com"/>*/}
            {/*</div>*/}
            {/*<div className="mb-3">*/}
            {/*    <label htmlFor="formGroupExampleInput2" className="form-label">Password</label>*/}
            {/*    <input type="password" className="form-control" id="formGroupExampleInput2"*/}
            {/*           placeholder="******"/>*/}
            {/*</div>*/}
            {/*<div className={style.bottomSection}>*/}
            {/*    <div className="form-check w-50">*/}
            {/*        <input className="form-check-input" type="checkbox" value="" id="flexCheckDefault"/>*/}
            {/*        <label className="form-check-label" htmlFor="flexCheckDefault">*/}
            {/*            Remember for 30 days*/}
            {/*        </label>*/}

            {/*    </div>*/}
            {/*    <div>*/}
            {/*        <a className={`text-decoration-none`} style={{color: "#98B3DB"}} href="#">Forgot password</a>*/}
            {/*    </div>*/}
            {/*</div>*/}
            {/*<div className="btn-group-vertical w-100" role="group" aria-label="Vertical button group">*/}
            {/*    <button type="button" className="btn mt-2 rounded" style={{backgroundColor: "#98B3DB"}}>Button</button>*/}
            {/*    <button type="button" className="btn mt-3 rounded" style={{borderColor: "#98B3DB"}}>Button</button>*/}
            {/*    <p className="text-center w-100 mt-3">Don't have an account? <a className=" text-decoration-none" href="#" style={{color: "#98B3DB"}}>Sign up!</a></p>*/}
            {/*</div>*/}
        </div>
    );
}

export default Header;