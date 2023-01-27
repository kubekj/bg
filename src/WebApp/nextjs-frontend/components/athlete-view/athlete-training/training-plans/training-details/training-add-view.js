import TopHeader from "../../../../reusable-comps/top-header";
import style from "./training-add-view.module.css"
import ExerciseDropdown from "./exercise-dropdown";
import Button from "../../../../reusable-comps/button";

const TrainingAddView = () => {

    return(
        <div className={style.container}>
            <TopHeader
                title="Create new training"
                text="Provide details"
                href="/athlete-all-trainings"
            />
            <div className={style.name}>
                <h5>Name</h5>
                <div className="input-group mb-3">
                    <input type="text" className="form-control" placeholder="Add name" aria-label="Username"
                           aria-describedby="basic-addon1" />
                </div>
                <p>In the below box please specify exercises, sets and reps to create a workout</p>
            </div>
            <div className={style.choices}>
                <ExerciseDropdown/>
                <ExerciseDropdown/>
                <ExerciseDropdown/>
                <ExerciseDropdown/>
                <ExerciseDropdown/>
            </div>
            <div className={style.buttons}>
                <Button iconSrc="/thumbnails/remove-circle-outline.svg"
                        borderValue="none"
                        backgroundColorValue="#D92D20"
                        isHoveringColor="#FFB2B2"
                        extraStyleType="color"
                        extraStyleValue="#8098F9"
                />
                <Button iconSrc="/thumbnails/add-circle-outline.svg"
                        borderValue="none"
                        backgroundColorValue="#8098F9"
                        isHoveringColor="#C7D7FE"
                        extraStyleType="color"
                        extraStyleValue="#8098F9"
                />
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
                                style={{backgroundColor:"#8098F9", color:"white", border:"none"}}>Add</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default TrainingAddView;