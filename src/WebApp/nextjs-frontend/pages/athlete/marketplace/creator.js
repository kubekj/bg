import Athlete from "../../../components/layouts/Athlete";
import { getSession } from "next-auth/react";
import fetcher from "../../../lib/rest-api";
import BuyTrainingView from "../../../components/athlete/marketplace/buy-training-view";
import CreatorView from "../../../components/athlete/marketplace/creator-view";


export async function getServerSideProps(context) {
    const session = await getSession({ req: context.req });

    if (!session) {
        return {
            redirect: {
                destination: "/auth/login",
                permanent: false,
            },
        };
    }

    const options = {
        headers: {
            Authorization: `Bearer ${session.jwt}`,
        },
    };

    const creatorDetails = await fetcher(`users/details`, options);

    return {
        props: { jwt: session.jwt, creatorDetails: creatorDetails},
    };
}

const Creator = ({ jwt, creatorDetails }) => {
    return <CreatorView creatorDetails={creatorDetails}/>
};

export default Creator;

Creator.layout = Athlete;