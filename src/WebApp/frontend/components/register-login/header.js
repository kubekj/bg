import style from './header.module.css'
import Image from 'next/image'
import logo from '../../public/logo.png'

const Header = () => {

    return(
        <div className={style.container}>
            <Image src="/public/logo.png" width={56} height={45} alt="BG logo" />
            <h1 className={style.title}>Log in to your account</h1>
            <p className={style.welcome}>Welcome back! Please enter your details</p>
        </div>
    );
}

export default Header;