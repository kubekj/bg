import style from "../training-main-view/training-plan.module.css";
import React from "react";
import Button from "../../../reusable-comps/button";
import Link from "next/link";

const LatestExercises = ({exercises}) => {

    return (
        <div className={style.container} style={{marginBottom:"1rem"}}>
            <div className={style.header}>
                <div className={style.info}>
                    <div>
                        <h5>
                            <b>Latest exercises</b>
                        </h5>
                    </div>
                    <div style={{ marginBottom: "0.75rem" }}>
                        <Link href='/athlete/exercise'>
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
                        <th className={style.thRegular}>Exercise name</th>
                        <th className={style.thRegular}>Category</th>
                        <th className={style.thRegular}>Body part</th>
                    </tr>
                    </thead>
                    <tbody className={style.tBody}>
                    {exercises.map(exercise => {
                        return (
                            <tr key={exercise.id}>
                                <td className={style.tdRegular}>{exercise.name}</td>
                                <td className={style.tdRegular}>{exercise.category}</td>
                                <td className={style.tdRegular}>{exercise.bodyPart}</td>
                            </tr>
                        );
                    })}
                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default LatestExercises;