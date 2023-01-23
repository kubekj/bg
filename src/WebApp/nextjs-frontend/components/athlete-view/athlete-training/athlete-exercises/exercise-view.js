import style from "./exercise-view.module.css";
import TopHeader from "../../reusable-comps/top-header";

const ExerciseView = ({title, btnRightLabel}) => {
    return(
        <div className={style.container}>
            <TopHeader
                title={title}
                text="Provide details"
                href="/athlete-exercises"
            />
            <div className={style.choices} style={{paddingTop:"1rem"}}>
                <label className={style.label}><b>Name</b></label>
                <div className="input-group mb-3">
                    <input type="text" className="form-control" placeholder="Add name" aria-label="Username"
                           aria-describedby="basic-addon1" />
                </div>
                <label className={style.label}><b>Body part</b></label>
                <div className="input-group mb-3">
                    <select className="form-select" id="inputGroupSelect01">
                        <option selected>Select body part</option>
                        <option value="1">One</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
                    </select>
                </div>
                <label className={style.label}><b>Category</b></label>
                <div className="input-group mb-3">
                    <select className="form-select" id="inputGroupSelect01">
                        <option selected>Select category</option>
                        <option value="1">One</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
                    </select>
                </div>
                <label className={style.label}><b>Select exercise</b></label>
            </div>
            <div style={{paddingTop:"1rem"}}>
                <div className="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
                    <div className="btn-group me-2 w-auto flex-fill" role="group" aria-label="First group">
                        <button type="button" className="btn btn-primary"
                                style={{backgroundColor:"#F5F5F5",color:"black", border:"1px solid #D0D5DD"}}
                        >Cancel</button>
                    </div>
                    <div className="btn-group me-2 w-auto flex-fill" role="group" aria-label="Third group">
                        <button type="button" className="btn btn-info"
                                style={{backgroundColor:"#8098F9", color:"white", border:"none"}}>{btnRightLabel}</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default ExerciseView;