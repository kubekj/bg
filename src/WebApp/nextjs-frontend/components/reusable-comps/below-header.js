import style from "./below-header.module.css"

const BelowHeader = ({title, text}) => {

    return(
        <div className={style.container}>
            <div className={style.top}>
                <div className={style.title}>
                    <div>
                        <h2>{title}</h2>
                        <p>{text}</p>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default BelowHeader;