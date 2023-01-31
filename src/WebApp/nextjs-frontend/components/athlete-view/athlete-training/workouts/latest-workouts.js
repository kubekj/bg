import style from "../../athlete-training/training-main-view/training-plan.module.css";
import React from "react";
import Button from "../../../reusable-comps/button";
import Link from "next/link";

const LatestWorkouts = ({workouts}) => {

    return (
        <div className={style.container} style={{marginBottom:"1rem"}}>
            <div className={style.header}>
                <div className={style.info}>
                    <div>
                        <h5>
                            <b>Latest workouts</b>
                        </h5>
                    </div>
                    <div style={{ marginBottom: "0.75rem" }}>
                        <Link href='/athlete/workout'>
                            <Button
                                iconSrc='/thumbnails/copy-outline.svg'
                                text='See all'
                                backgroundColorValue='white'
                                isHoveringColor='#D0D5DD'
                                extraStyleType='border'
                                extraStyleValue='1px solid #D0D5DD'
                            />
                        </Link>
                    </div>
                </div>
            </div>
            <div className={style.midSection}>
                <table className={style.tableOfTrainings}>
                    <thead className={style.tHead}>
                    <tr>
                        <th className={style.thRegular}>Workout name</th>
                        <th className={style.thRegular}>Category</th>
                        <th className={style.thRegular}>No. of exercises</th>
                    </tr>
                    </thead>
                    <tbody className={style.tBody}>
                    {workouts.map((workout) => {
                        return (
                            <tr key={workout.id}>
                                <td className={style.tdRegular}>{workout.name}</td>
                                <td className={style.tdRegular}>{workout.category}</td>
                                <td className={style.tdRegular}>{workout.exerciseDtos.length}</td>
                            </tr>
                        );
                    })}
                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default LatestWorkouts;
