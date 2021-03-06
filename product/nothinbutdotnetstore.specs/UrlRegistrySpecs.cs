using System;
using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhino;
using Machine.Specifications;

namespace nothinbutdotnetstore.specs
{
    public class UrlRegistrySpecs
    {
        public abstract class concern : Observes<UrlRegistry,
                                            DefaultUrlRegistry>
        {
        }


        [Subject(typeof(DefaultUrlRegistry))]
        public class when_getting_the_path_for_a_registered_type : concern
        {
            Establish c = () =>
            {
                the_path = "blah";
                the_type_to_look_up = typeof(string);

                add_pipeline_behaviour_against_sut(
                    x => x.downcast_to<DefaultUrlRegistry>().Add(the_type_to_look_up, the_path));
            };

            Because b = () =>
                result = sut.get_path(the_type_to_look_up);

            static Type the_type_to_look_up;

            It should_return_the_registered_path = () => result.ShouldEqual(the_path);
            static string the_path;
            static string result;
        }

        public class when_getting_the_path_for_a_type_thats_not_registered : concern
        {
            Because b = () =>
                catch_exception(()=>sut.get_path(typeof(string)));

            It should_throw_a_no_path_registered_for_type_exeception =
                () => exception_thrown_by_the_sut.ShouldBeAn<KeyNotFoundException>();
        }
    }
}