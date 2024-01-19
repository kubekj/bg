import React from "react";
import Button from "../../../reusable/button";
import Link from "next/link";

const LatestExercises = ({exercises}) => {
    return (
        <>
            <div className='relative flex flex-col min-w-0 break-words bg-white w-full mb-6 shadow-md rounded-xl'>
                <div className='rounded-t py-3 border-0'>
                    <div className='flex flex-wrap items-center'>
                        <div className='relative w-full px-4 max-w-full flex-grow flex-1'>
                            <h3 className='font-semibold text-base text-blueGray-700 my-auto'>
                                Latest exercises
                            </h3>
                        </div>
                        <div className='relative w-full px-4 max-w-full flex-grow flex-1 text-right'>
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
                <div className='block w-full overflow-x-auto'>
                    <table className='items-center w-full bg-transparent border-collapse'>
                        <thead className='thead-light bg-indigo-400 text-white'>
                        <tr>
                            <th className='px-6 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                                Name
                            </th>
                            <th className='px-6  align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                                Category
                            </th>
                            <th className='px-6 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                                Body Part
                            </th>
                        </tr>
                        </thead>
                        <tbody className='divide-y divide-gray-200'>
                        {(exercises && exercises.length !== 0) ? exercises.map((exercise) => {
                            return (
                                <tr key={exercise.id}>
                                    <td className='text-xs p-4'>{exercise.name}</td>
                                    <td className='text-xs p-4'>{exercise.category}</td>
                                    <td className='text-xs p-4'>{exercise.bodyPart}</td>
                                </tr>
                            );
                        }) : <React.Fragment/>}
                        </tbody>
                    </table>
                </div>
            </div>
        </>
    );
};

export default LatestExercises;
