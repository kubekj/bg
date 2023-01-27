import style from "./training-add-view.module.css";
import TopHeader from "../../../../reusable-comps/top-header";
import DetailsTraining from "./details-training";

const TrainingDetailsMoreView = () => {

    return(
        <div className={style.container}>
            <TopHeader
                title="Training"
                text="Training details provided below"
                href="/athlete-all-trainings"
            />
            <div className={style.name}>
                <h3>Plan</h3>
                <p>A plan meant for developing back and core</p>
            </div>
            <div className={style.choices}>
                <DetailsTraining ifDisabled={true}/>
                <DetailsTraining ifDisabled={true}/>
                <DetailsTraining ifDisabled={true}/>
                <DetailsTraining ifDisabled={true}/>
                <DetailsTraining ifDisabled={true}/>
            </div>
            <div style={{paddingTop:"1rem"}}>
                <div className="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
                    <div className="btn-group me-2 w-auto flex-fill" role="group" aria-label="First group">
                        <button type="button" className="btn btn-primary"
                                style={{backgroundColor:"#8098F9",color:"white", border:"1px solid #D0D5DD"}}
                        >Start</button>
                    </div>
                </div>
            </div>
            <div style={{paddingTop:"1rem"}}>
                <div className="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
                    <div className="btn-group me-2 w-auto flex-fill" role="group" aria-label="First group">
                        <button type="button" className="btn btn-primary"
                                style={{backgroundColor:"#F5F5F5",color:"black", border:"1px solid #D0D5DD"}}
                        >Close</button>
                    </div>
                    <div className="btn-group me-2 w-auto flex-fill" role="group" aria-label="Third group">
                        <button type="button" className="btn btn-info"
                                style={{backgroundColor:"#F5F5F5", color:"black", border:"1px solid #D0D5DD"}}>Edit</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default TrainingDetailsMoreView;